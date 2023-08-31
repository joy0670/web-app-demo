'use client';

import { Card, Metric, Text, Title, BarList, Flex, Grid, Col, NumberInput, Divider, Callout, Icon} from '@tremor/react';
import { BellAlertIcon } from '@heroicons/react/24/solid'
import Chart from './chart';

const Import = [
  { name: 'B2S', value: 153 },
  { name: 'VAS', value: 52 },
];

const done = [
  { name: 'B2S', value: 856 },
  { name: 'VAS', value: 2368 },
];

const ratio = [
  { name: 'B2S', value: 153 },
  { name: 'VAS', value: 52 },
];

const fte = [
  { name: 'Direct', value: 23 },
  { name: 'Indirect', value: 3 },
];

const data = [
  {
    category: 'Import',
    stat: '10,234',
    data: Import
  },
  {
    category: 'Done',
    stat: '12,543',
    data: done
  },
  {
    category: 'Ratio',
    stat: '84',
    data: ratio
  }
];

const fteCard =[
  {
    category: 'FTE',
    stat: '25',
    data: fte
  },
]

const wip =[
  {
    startwip: 8975,
    endwip: 5486,
  }
]


export default function ShopPickPage() {
  return (
    <main className="p-4 md:p-10 mx-auto max-w-7xl">
      <Grid numItems={1} numItemsSm={2} numItemsLg={4} className="gap-6">
        {data.map((item) => (
          <Card key={item.category}>
            <Title>{item.category}</Title>
            <Flex
              justifyContent="start"
              alignItems="baseline"
              className="space-x-2"
            >
              <Metric>{item.stat}</Metric>
              <Text>Total</Text>
            </Flex>
            <Flex className="mt-6">
              <Text>Order type</Text>
              <Text className="text-right"></Text>
            </Flex>
            <BarList
              data={item.data}
              valueFormatter={(number: number) =>
                Intl.NumberFormat('us').format(number).toString()
              }
              className="mt-2"
            />
          </Card>
        ))}
        {fteCard.map((item) => (
          <Card key={item.category}>
            <Title>{item.category}</Title>
            <Flex
              justifyContent="start"
              alignItems="baseline"
              className="space-x-2"
            >
              <Metric>{item.stat}</Metric>
              <Text>Total</Text>
            </Flex>
            <Flex className="mt-6">
              <Text>FTE type</Text>
              <Text className="text-right"></Text>
            </Flex>
            <BarList
              data={item.data}
              valueFormatter={(number: number) =>
                Intl.NumberFormat('us').format(number).toString()
              }
              className="mt-2"
            />
          </Card>
        ))}
        <Col numColSpan={1} numColSpanLg={3}>
          <Chart />
        </Col>
        <Card>
            {/* Your card content */}
            <Title>Start Wip</Title>
            <Metric>5869</Metric>
            <Divider></Divider>
            <Title className='mb-4'>Expect end Wip</Title>
            <NumberInput  />
            <Divider></Divider>
            <Callout className="mt-4" title="Suggestions" icon={BellAlertIcon } color="teal">
              All systems are currently within their default operating ranges.
            </Callout>
          </Card>
      </Grid>
    </main>
  );
}
